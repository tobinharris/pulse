class CreateMeasurements < ActiveRecord::Migration
  def self.up
    create_table :measurements do |t|
      t.string :key
      t.float :value

      t.timestamps
    end
  end

  def self.down
    drop_table :measurements
  end
end
