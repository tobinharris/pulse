require 'mongo'

class MdashController < ApplicationController
  def index
      db = XGen::Mongo::Driver::Mongo.new("localhost"); 
      db.db("test");
      #@measurments  = db.collection("measurements").find();
  end  
end