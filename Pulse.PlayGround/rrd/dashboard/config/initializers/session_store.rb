# Be sure to restart your server when you modify this file.

# Your secret key for verifying cookie session data integrity.
# If you change this key, all old sessions will become invalid!
# Make sure the secret is at least 30 characters and all random, 
# no regular words or you'll be exposed to dictionary attacks.
ActionController::Base.session = {
  :key         => '_dashboard_session',
  :secret      => 'b810a215c4a77555b5f8c1a61e6b3c15188b9d36f95f93bab06076d349f38f0c044537daf835e23abe7cb45b43c145c0a5f61c448f3915a59e8d9ed4fe3f3ee7'
}

# Use the database for sessions instead of the cookie-based default,
# which shouldn't be used to store highly confidential information
# (create the session table with "rake db:sessions:create")
# ActionController::Base.session_store = :active_record_store
