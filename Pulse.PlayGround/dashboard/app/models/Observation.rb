class Observation < CouchRest::ExtendedDocument
  Observation.use_database DB
  view_by :RecordedAt, :descending=>true
  property :RecordedAt #, :cast_as=>['Date']
  property :Value
  property :TypeKey
    
end