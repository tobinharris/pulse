class DashboardController < ApplicationController
  def index
    @items =  Observation.by_RecordedAt     
    data = {}   
     
    #  build up for charts. Create hash of data a bit like this "mysql.connections"=>[ ['2009-09-01 05:34:01',78], ['2009-09-01 05:44:01',87] ]
    @items.each{ |i| data[i.TypeIdentifier].nil? ? data[i.TypeIdentifier] = [[i.RecordedAt, i.Value]] : data[i.TypeIdentifier] << [i.RecordedAt, i.Value]}

    # use data to build charts
    @charts = []
    data.keys.each do |key|
      c = DashboardHelper::Chart.new(key, data[key])
      @charts << c
    end
  end  
end

