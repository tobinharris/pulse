class MdashController < ApplicationController
  def index       
      @pulse_db = Connection.new.db('pulse_mdl')
      @measurments  = @pulse_db.collection("measurements").find();     
      @heartbeats  = @pulse_db.collection("measurements").find('TypeKey' => 'Common.Heartbeat');
  end  
end