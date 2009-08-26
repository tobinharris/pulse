require 'rubygems'
require 'json/pure'
require 'fileutils'
require 'mongo'

folder = "C:/temp/sample_observations"
@db = XGen::Mongo::Driver::Mongo.new("localhost").db("mdl_pulse")
@measurements = @db.collection("measurements")
for_a_minute = 1

return if not File.exist?(folder)
Dir.chdir(folder)

while(true)  
  Dir["*"].entries.each do |file|
    if File.file?(file) and File.readable?(file) and File.extname(file) != '.txt'
      payload = JSON.parse(IO.read(file))
      @measurements.insert payload unless payload.nil?
      FileUtils.rm(file)
      sleep for_a_minute
    end
  end
end
