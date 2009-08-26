require 'mongo'
include Mongo
  
  
class MdashController < ApplicationController
  def index 
      db = Connection.new.db('pulse_mdl')
      #db = XGen::Mongo::Driver::Mongo.new.db("pulse_mdl")
      #@measurments  = db.collection("measurements").find();
  end  
end