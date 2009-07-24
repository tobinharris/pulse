require 'rubygems'
require '../Client/Pulse'
require 'sys/cpu'
require 'sys/filesystem'
include Sys


def disk_used_space( path )
  `df -P #{path} |grep ^/ | awk '{print $3;}'`.
    to_i * 1.kilobyte
end

def disk_free_space( path )
  `df -Ph | grep ^#{path} | awk '{print $4;}'`.
   to_i * 1024
end

# Define node and measurements
node = {:Identifier=>'mdl.web', :Name=>'MDL Web Site', :Descriptor=>'MDL Portal Web Server' }
cpu_usage = {:Identifier=>'cpu.usage.perminute', :name=>'CPU Usage', :Description=>'Average CPU Usage Over 1 Minute', :Unit=>'%'}
disk_usage = {:Identifier=>'disk.usage', :Name=>'Disk Usage', :Descriptor=>'Current Disk Usage', :Unit=>'Mb'}

# Set up Pulse
pulse = Pulse.new('C2AH567BG90C', MockDb.new)
pulse.observes node
pulse.measures cpu_usage
pulse.measures disk_usage

while(true) do  
  pulse.record CPU.load_avg[0], cpu_usage[:Identifier], node  
  #pulse.record_measurement disk_free_space('/dev/disk0s2') / 1024, disk_usage[:key]
  sleep 10
end
