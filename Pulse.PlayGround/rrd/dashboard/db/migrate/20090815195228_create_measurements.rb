class CreateMeasurements < ActiveRecord::Migration
  def self.up
    create_table :measurements do |t|
      t.integer :instance_id
      t.integer :node_id
      t.string :name
      t.float :value      
      t.timestamps
    end
  end

  def self.down
    drop_table :measurements
  end
end
