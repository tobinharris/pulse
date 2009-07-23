require 'rubygems'
require 'sys/cpu'
require 'sys/filesystem'
require 'couchrest'
require 'json/pure'
include Sys

# Pulse (talks direct to couch)
class Pulse  
  
  def initialize(api_key, app)
    @db = CouchRest.database!("http://127.0.0.1:5984/pulse_mdl") 
    @api_key = api_key
    @app = app
    @origin = `hostname`    
    emit(app)
  end
  
  def measures(hash)
    hash[:api_key] = @api_key
    hash[:document_type]='observation_type'
    emit(hash)
  end
  
  def measure(val, type)
    # Augement with additional data if necessary
    hash = {}
    hash[:document_type] = 'observation.measurement'
    hash[:api_key] = @api_key    
    hash[:type] = type
    hash[:app] = @app[:key] 
    hash[:recorded_at] = Time.new.utc 
    hash[:value] = val
    emit(hash)
  end  
  
  private
  
  def emit(hash)
    hash[:origin] = @origin
    @db.save_doc(hash)
  end  
end

def diskusage
  s = Filesystem.stat("/")
  (s.blocks_free * s.block_size)
end

# Create types

app = 
  {
    :document_type=>'node',
    :key=>'mdl.web',
    :name=>'MDL Web Site', 
    :description=>'MDL Portal Web Site'  
  }

cpu_usage = 
  { 
    :key=>'cpu.usage.perminute',
    :name=>'CPU Usage', 
    :description=>'Average CPU Usage Over 1 Minute'
  }

disk_usage = 
  {    
    :key=>'disk.usage',
    :name=>'Disk Usage', 
    :description=>'Current Disk Usage'
  }

# Set up Pulse
pulse = Pulse.new('C2AH567BG90C', app)
pulse.measures(cpu_usage)
pulse.measures(disk_usage)

while(true) do  
  pulse.measure(CPU.load_avg[0], cpu_usage[:key])  
  pulse.measure(diskusage, disk_usage[:key])
  sleep 10
end
# function(doc) {
#    if(doc.document_type == 'observation'  
#       && doc.type=='cpu.usage.perminute'
#       && doc.api_key == 'C2AH567BG90C')
#    emit('average', parseFloat(doc.value) * 100);
# }