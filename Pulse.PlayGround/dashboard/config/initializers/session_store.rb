# Be sure to restart your server when you modify this file.

# Your secret key for verifying cookie session data integrity.
# If you change this key, all old sessions will become invalid!
# Make sure the secret is at least 30 characters and all random, 
# no regular words or you'll be exposed to dictionary attacks.
ActionController::Base.session = {
  :key         => '_dashboard_session',
  :secret      => '36aeb140774d67900c0447b02be7796e5fb183e89de210c4f727a3e2973f13f5c6659e5fbcdd116b3f0905eceec8bd37425e5312650b5a14917adb7f29f5fad3'
}

# Use the database for sessions instead of the cookie-based default,
# which shouldn't be used to store highly confidential information
# (create the session table with "rake db:sessions:create")
# ActionController::Base.session_store = :active_record_store
