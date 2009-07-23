require 'rubygems'
require 'couchrest'
require 'json/pure'

class Pulse  
  
  attr_accessor :db
  
  def initialize(api_key, node)   
    @api_key = api_key
    @node = node
    @origin = `hostname`        
    @node[:document_type] = 'node'    
    post app
  end
  
  def measures(measurement_type)
    measurement_type[:api_key] = @api_key
    measurement_type[:document_type] = 'observation_type'
    post measurement_type
  end
  
  def record_measurement(val, type)
    post 
      {
        :value = val,  
        :type = type,   
        :document_type = 'observation.measurement',
        :api_key = @api_key,
        :app = @node[:key],
        :recorded_at = Time.new.utc           
      }
  end  
  
  private
    
  def post(doc)
    doc[:origin] = @origin
    @db = CouchRest.database!("http://127.0.0.1:5984/pulse_mdl") if @db.nil?    
    @db.save_doc doc
  end  
  
end

# function(doc) {
#    if(doc.document_type == 'observation'  
#       && doc.type=='cpu.usage.perminute'
#       && doc.api_key == 'C2AH567BG90C')
#    emit('average', parseFloat(doc.value) * 100);
# }