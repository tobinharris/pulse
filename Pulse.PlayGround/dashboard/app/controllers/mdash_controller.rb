require 'mongo'
include Mongo
  
  
class MdashController < ApplicationController
  def index       
      @pulse_db = Connection.new.db('pulse_mdl')
      @measurments  = @pulse_db.collection("measurements").find();
  end  
end