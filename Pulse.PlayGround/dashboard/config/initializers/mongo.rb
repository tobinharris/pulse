require 'mongo'
include Mongo

@pulse_db = Connection.new.db('pulse_mdl')