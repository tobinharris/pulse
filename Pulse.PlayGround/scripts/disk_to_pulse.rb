require 'rubygems'
require 'json/pure'
require 'fileutils'
require '../client/MongoDb'

folder = "C:\\temp\\mdl"

db = MongoDb.new( Connection.new.db('pulse_mdl') )
for_a_minute = 1

return if not File.exist?(folder)
Dir.chdir(folder)

while(true)  
  Dir["*"].entries.each do |file|
    if File.file?(file) and File.readable?(file) and File.extname(file) != '.txt'
      payload = JSON.parse(IO.read(file))
      db.save_doc payload unless payload.nil?
      FileUtils.rm(file)
      sleep for_a_minute
    end
  end
end
