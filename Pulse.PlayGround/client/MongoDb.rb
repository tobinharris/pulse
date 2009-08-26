require 'rubygems'
require 'mongo'
include Mongo

class MongoDb   
  def initialize(mongodb=nil)
    @db = mongodb 
    @measurements = @db.collection("measurements")
  end
  
  def save_doc(doc)
    @measurements.insert doc
  end
end