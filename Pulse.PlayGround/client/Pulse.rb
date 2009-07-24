require 'rubygems'
require 'couchrest'
require 'json/pure'
require '../client/mockdb'

class Pulse  
  
  def initialize(api_key, db=MockDb.new)   
    @api_key = api_key
    @origin = `hostname`            
    @db = db
  end
  
  def observes(node)
    node['couchrest-type'] = 'Node'    
    post node
  end
  
  def measures(measurement_type)
    measurement_type[:api_key] = @api_key
    measurement_type['couchrest-type'] = 'ObservationType'
    post measurement_type
  end
  
  def record(val, type, node)
    post(
    {
        :value => val,  
        :type => type,   
        'couchrest-type' => 'Observation',
        :api_key => @api_key,
        :target_node => node[:key],        
        :recorded_at => Time.new.utc           
      })
  end  
  
  private
    
  def post(doc)
    doc[:originating_node] = @origin
    @db.save_doc doc
  end  
  
end

