class DashboardController < ApplicationController
  def index         
    # Create a new graph object.
    @received_packets_graph = RRDGraph.new("received_packets_total")
   
    @packets = Measurement.find :all, :order => "created_at ASC"
    
    # Generate a new RRD. (This will just be skipped if there is already a RRD with that name)
    @received_packets_graph.create_rrd "--start #{@packets[0].created_at.to_i - 2} DS:packets:GAUGE:600:U:U RRA:AVERAGE:0.5:1:24 RRA:LAST:0.5:1:1200"
    
    @received_packets_graph.insert @packets.map {|p| "#{p.created_at.to_f}:#{p.value.to_i}" }.join(' ')

    @graph_name = @received_packets_graph.get_name_of_graph               

    # Build some options for the graph image.
    yesterday = (1.day.ago).to_i
    lines = [ "DEF:packets=" + @received_packets_graph.get_path_of_rrd + ":packets:LAST CDEF:real=packets,1,\* AREA:real#eb7f00:'CPU Usage'" ]
    title = "Receiver: AIS CPU/Minute - " + Time.now.to_s
    width = "725"
    height = "40"
    options = "-Y -X 1"
    colors = {  "SHADEA" => "#FFFFFF",
                "SHADEB" => "#EEEEEE",
                "FONT" => "#000000",
                "BACK" => "#FFFFFF",
                "CANVAS" => "#FFFFFF",
                "GRID" => "#CCCCCC",
                "MGRID" => "#CCCCCC",
                "AXIS" => "#333333",
                "ARROW" => "#333333" }

    @received_packets_graph.update_image yesterday, Time.now.to_i, lines, title, width, height, colors, options

    # We can now display the graph's image with the show_graph helper.        
  end

end
