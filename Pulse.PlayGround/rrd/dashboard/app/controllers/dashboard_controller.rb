require 'mongo'
include Mongo 
class DashboardController < ApplicationController
  
# e.g. /dashboard/index/MVC_Controller_Time    
  def index                 
    graph_name = params[:id].nil? ? "MVC.Controller.Time" : params[:id].gsub('_','.')        
     
    # Create a new graph object.
    @received_packets_graph = RRDGraph.new(graph_name)
   
    @pulse_db = Connection.new('www.socena.com').db('pulse_mdl')
    @measurements = @pulse_db.collection("measurements").find('TypeKey'=>graph_name)
    #@measurements = @pulse_db.collection("measurements").find('TypeKey'=>'Common.Heartbeat')
    
    @packets = []
    
    last_time = nil    
    @measurements.each do |p|                                  
      if not (p["RecordedAt"].nil? and p["TimeStamp"].nil?) then      
        
        recorded_at = p["RecordedAt"].nil? ? p["TimeStamp"] : p["RecordedAt"]
        
        if not recorded_at.class == Time then
          datestring = recorded_at                 
          seconds_since_epoch = datestring.scan(/([0-9]+)\+([0-9]+)/)[0][0].to_i            
          timezone = datestring.scan(/([0-9]+)\+([0-9]+)/)[0][1].to_i            
          recorded_at = Time.at(seconds_since_epoch.to_s[0..9].to_i,seconds_since_epoch.to_s[10..12].to_i)          
        end
        
        packet = {
          "Value"=>p["Value"],
          "RecordedAt" => recorded_at
          }                           
         
        @packets << packet unless packet["RecordedAt"].nil? or (not last_time.nil? and (packet["RecordedAt"] - last_time) < 1)
        
        last_time = packet["RecordedAt"]
      end
    end                                                     
   
    throw "Nothing recorded for '#{graph_name}'." if @packets.empty?
    
    #@packets = Measurement.find :all, :order => "created_at ASC"
    
    # Generate a new RRD. (This will just be skipped if there is already a RRD with that name)
    @received_packets_graph.create_rrd "--start #{@packets[0]["RecordedAt"].to_i} DS:packets:GAUGE:86400:U:U RRA:AVERAGE:0.5:1:1200 RRA:LAST:0.5:1:1200"
    
    @received_packets_graph.insert @packets.map {|p| "#{p["RecordedAt"].to_f}:#{p["Value"].to_i}" }.join(' ')
    
    @graph_name = @received_packets_graph.get_name_of_graph               

    # Build some options for the graph image.
    start_time = (5.days.ago).to_i
    lines = [ "DEF:packets=" + @received_packets_graph.get_path_of_rrd + ":packets:LAST CDEF:real=packets AREA:real#eb7f00:#{graph_name}" ]
    title = graph_name + " - " + Time.now.to_s
    width = "725"
    height = "120"
    options = ""
    colors = {  "SHADEA" => "#FFFFFF",
                "SHADEB" => "#EEEEEE",
                "FONT" => "#000000",
                "BACK" => "#FFFFFF",
                "CANVAS" => "#FFFFFF",
                "GRID" => "#CCCCCC",
                "MGRID" => "#CCCCCC",
                "AXIS" => "#333333",
                "ARROW" => "#333333" }

    @received_packets_graph.update_image start_time, Time.now.to_i, lines, title, width, height, colors, options

    # We can now display the graph's image with the show_graph helper.        
  end

end
