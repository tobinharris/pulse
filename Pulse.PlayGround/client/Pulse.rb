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
    measurement_type[:ApiKey] = @api_key
    measurement_type['couchrest-type'] = 'ObservationType'
    post measurement_type
  end
  
  def record(val, type, node)
    post(
    {
        :Value => val,  
        :TypeIdentifier => type,   
        'couchrest-type' => 'Observation',
        :ApiKey  => @api_key,
        :TargetNode  => node[:key],        
        :RecordedAt => Time.new.utc           
      })
  end  
  
  private
    
  def post(doc)
    doc[:OriginatingNode] = @origin
    @db.save_doc doc
  end  
  
end

