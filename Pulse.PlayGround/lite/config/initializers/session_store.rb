# Be sure to restart your server when you modify this file.

# Your secret key for verifying cookie session data integrity.
# If you change this key, all old sessions will become invalid!
# Make sure the secret is at least 30 characters and all random, 
# no regular words or you'll be exposed to dictionary attacks.
ActionController::Base.session = {
  :key         => '_lite_session',
  :secret      => '512c02d619f823261ee1b80a0222eab1b96d142c4bab6feccf7c00d189d369d259e5a5787831e39a10f3b68b60fb03af1e4f669c3d810a4028b06fb4ec4d824e'
}

# Use the database for sessions instead of the cookie-based default,
# which shouldn't be used to store highly confidential information
# (create the session table with "rake db:sessions:create")
# ActionController::Base.session_store = :active_record_store
