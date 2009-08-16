require 'rubygems'
require 'mongo'

class MongoDb   
  def initialize(mongodb=nil)
    @db = mongodb #|| XGen::Mongo::Driver::Mongo.new("localhost").db("mdl_pulse") 
    @measurements = @db.collection("measurements")
  end
  
  def save_doc(doc)
    @measurements.insert doc
  end
end