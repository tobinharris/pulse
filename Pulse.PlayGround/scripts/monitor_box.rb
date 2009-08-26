require 'rubygems'
require '../Client/Pulse'     
require '../Client/MongoDb'     
require 'sys/cpu'
require 'sys/filesystem'
include Sys
require 'mysql'
require 'mongo'
include Mongo

def disk_used_space( path )
  `df -P #{path} |grep ^/ | awk '{print $3;}'`.
    to_i * 1.kilobyte
end

def disk_free_space( path )
  `df -Ph | grep ^#{path} | awk '{print $4;}'`.
   to_i * 1024
end

# Define nodes
node = {:Identifier=>`hostname`, :Name=>`hostname`, :Descriptor=>'' }
mysql = {:Identifier=>'mysql', :Name=>'MySQL Server', :Descriptor=>'', }

# Set up Pulse
db = MockDb.new
#db = CouchRest.database!("http://192.168.1.119:5984/pulse_mdl")
db = MongoDb.new( Connection.new.db('pulse_mdl') )



pulse = Pulse.new('C2AH567BG90C', db)
pulse.observes node
pulse.observes mysql

while(true) do  
  pulse.record CPU.load_avg[0] * 100, 'cpu.usage', node  
  pulse.record Filesystem.stat("/").blocks_free, 'disk.freeblocks', node
  
  #record MySQL stuff
  #db = Mysql.real_connect("127.0.0.1","root","root",nil,8889) 
  #st = db.query("show global status like 'Threads_%';")     
  #st.each do |row| 
  #  pulse.record row[1].to_f, "mysql.#{row[0].downcase().gsub(/_/,'.')}" , mysql
  #end  
  #db.close()
  sleep 10
end
