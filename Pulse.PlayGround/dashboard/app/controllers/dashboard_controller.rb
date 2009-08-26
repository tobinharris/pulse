class DashboardController < ApplicationController
  layout 'default'
  
  def index
    @pulse_db = Connection.new.db('pulse_mdl')
    @items= @pulse_db.collection("measurements").find();
    
    
    data = {}   
    
    #  build up for charts. 
    # Create hash of data a bit like this "mysql.connections"=>[ ['2009-09-01 05:34:01',78], ['2009-09-01 05:44:01',87] ]
    @items.each do |i| 
      
      data[i["TypeKey"]].nil? ? data[i["TypeKey"]] = [[i["RecordedAt"], i["Value"]]] : data[i["TypeKey"]] << [i["RecordedAt"], i["Value"]] unless i["TypeKey"].nil?
    end
    
    data.sort{|a,b| b <=> a unless (a.nil? or b.nil?) }

    # use data to build charts
    @charts = {}
    data.keys.each do |key|
      c = DashboardHelper::Chart.new(key, data[key])
      @charts[key] = c
    end
  end  
  
  def preload_observation_types
    types = {}
  end
end

