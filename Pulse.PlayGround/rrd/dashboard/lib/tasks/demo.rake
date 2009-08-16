namespace :demo do
  desc "Prepare some demo data"
  
  task :default => [:prepare]
  
  task :prepare =>  [:environment] do                                         
    Measurement.delete_all
    
    (0..300).each do |i|
      Measurement.create! :name => 'cpu.usage', :value => rand(100), :created_at => 1.day.ago + i*60*5
    end
  end
end