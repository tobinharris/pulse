require 'rubygems'
require 'Pulse'
require 'sys/cpu'
require 'sys/filesystem'
include Sys


def disk_used_space( path )
  `df -P #{path} |grep ^/ | awk '{print $3;}'`.
    to_i * 1.kilobyte
end

def disk_free_space( path )
  `df -P #{path} |grep ^/ | awk '{print $4;}'`.
    to_i * 1.kilobyte
end

# Define node and measurements
node = {:key=>'mdl.web', :name=>'MDL Web Site', :description=>'MDL Portal Web Server' }
cpu_usage = {:key=>'cpu.usage.perminute', :name=>'CPU Usage', :description=>'Average CPU Usage Over 1 Minute'}
disk_usage = {:key=>'disk.usage', :name=>'Disk Usage', :description=>'Current Disk Usage'}

# Set up Pulse
pulse = Pulse.new('C2AH567BG90C', app)
pulse.measures cpu_usage
pulse.measures disk_usage

while(true) do  
  pulse.record_measurement CPU.load_avg[0], cpu_usage[:key]  
  pulse.record_measurement disk_free_space("/dev/disk0s2") / 1024, disk_usage[:key]
  sleep 10
end
