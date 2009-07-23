require 'rubygems'
require 'sinatra'
require 'couchrest'
require 'json/pure'

class Measurement < CouchRest::ExtendedDocument
  view_by :recorded_at, :descending => true
  view_by :type,
    :map => 
      "function(doc) {
        if (doc['couchrest-type'] == 'observation.measurement') {          
            emit(null, doc);          
        }
      }" 
  property :value
  property :type
  property :origin
  property :recorded_at
end

get '/' do
  Measurement.use_database CouchRest.database!("http://127.0.0.1:5984/pulse_mdl")  
  @items = Measurement.by_type.paginate(:page => 1, :per_page => 50)
  @items.sort{| a,b | a.recorded_at <=> b.recorded_at }
  @chart = "http://chart.apis.google.com/chart?cht=ls&chs=300x100&chm=B,e6f2fa,0,0,0|R,000000,0,0.998,1.0&chco=0f7fcf&chxt=r&chd=s:#{@items.map{|i|i.value * 100}.join(',')}"
  erb :dash
end