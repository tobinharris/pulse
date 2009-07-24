require 'rubygems'
require 'sinatra'
require 'couchrest'
require 'json/pure'

DB = CouchRest.database("http://localhost:5984/pulse_mdl")     

class Observation < CouchRest::ExtendedDocument
  Observation.use_database DB
end


get '/setup' do  
  db = CouchRest.database!("http://localhost:5984/pulse_mdl")     
  db.save_doc Observation.new
  db.save_doc Observation.new
end

get '/' do  
  @items =  Observation.first
  
  #@items.sort{| a,b | a.recorded_at <=> b.recorded_at }
  #@chart = "http://chart.apis.google.com/chart?cht=ls&chs=300x100&chm=B,e6f2fa,0,0,0|R,000000,0,0.998,1.0&chco=0f7fcf&chxt=r&chd=s:#{@items.map{|i|i.value * 100}.join(',')}"
  erb :dash
end