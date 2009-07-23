require 'rubygems'
require 'couchrest'
require 'json/pure'
require '../client/mockdb'

class Pulse  
  
  def initialize(api_key, node, db=MockDb.new)   
    @api_key = api_key
    @node = node
    @origin = `hostname`        
    @node['couchrest-type'] = 'node'    
    @db = db
    post node
  end
  
  def measures(measurement_type)
    measurement_type[:api_key] = @api_key
    measurement_type['couchrest-type'] = 'observation_type'
    post measurement_type
  end
  
  def record_measurement(val, type)
    post(
    {
        :value => val,  
        :type => type,   
        'couchrest-type' => 'observation.measurement',
        :api_key => @api_key,
        :app => @node[:key],
        :recorded_at => Time.new.utc           
      })
  end  
  
  private
    
  def post(doc)
    doc[:origin] = @origin
    @db.save_doc doc
  end  
  
end

