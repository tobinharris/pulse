class MeasurementsController < ApplicationController
  # GET /measurements
  # GET /measurements.xml
  def index
    @measurements = Measurement.all

    respond_to do |format|
      format.html # index.html.erb
      format.xml  { render :xml => @measurements }
    end
  end

  # GET /measurements/1
  # GET /measurements/1.xml
  def show
    @measurement = Measurement.find(params[:id])

    respond_to do |format|
      format.html # show.html.erb
      format.xml  { render :xml => @measurement }
    end
  end

  # GET /measurements/new
  # GET /measurements/new.xml
  def new
    @measurement = Measurement.new

    respond_to do |format|
      format.html # new.html.erb
      format.xml  { render :xml => @measurement }
    end
  end

  # GET /measurements/1/edit
  def edit
    @measurement = Measurement.find(params[:id])
  end

  # POST /measurements
  # POST /measurements.xml
  def create
    @measurement = Measurement.new(params[:measurement])

    respond_to do |format|
      if @measurement.save
        flash[:notice] = 'Measurement was successfully created.'
        format.html { redirect_to(@measurement) }
        format.xml  { render :xml => @measurement, :status => :created, :location => @measurement }
      else
        format.html { render :action => "new" }
        format.xml  { render :xml => @measurement.errors, :status => :unprocessable_entity }
      end
    end
  end

  # PUT /measurements/1
  # PUT /measurements/1.xml
  def update
    @measurement = Measurement.find(params[:id])

    respond_to do |format|
      if @measurement.update_attributes(params[:measurement])
        flash[:notice] = 'Measurement was successfully updated.'
        format.html { redirect_to(@measurement) }
        format.xml  { head :ok }
      else
        format.html { render :action => "edit" }
        format.xml  { render :xml => @measurement.errors, :status => :unprocessable_entity }
      end
    end
  end

  # DELETE /measurements/1
  # DELETE /measurements/1.xml
  def destroy
    @measurement = Measurement.find(params[:id])
    @measurement.destroy

    respond_to do |format|
      format.html { redirect_to(measurements_url) }
      format.xml  { head :ok }
    end
  end  

  require 'gruff'
  def report     
    # hash.to_s.gsub('-','').to_i.to_s(16)
    
    
    found = Measurement.find_by_sql("select m.key, m.value, m.created_at from Measurements m order by m.created_at desc")
    vals = found.map {|v| v.value }
    times={}
    
    hash = found[0].key.hash.to_s.gsub('-','').to_i.to_s(16)
    g = Gruff::Line.new

    g.theme_greyscale
    g.title = found[0].key
    g.data(found[0].key, vals)
    i = 0
    found.each{ |v| times[i] = v.created_at.strftime('%M'); i+=1 }
    g.labels = times
    file ="#{RAILS_ROOT}/public/images/#{hash}.png"
    g.write(file)     
    render :text=>"<img src='/images/#{hash}.png' />"
  end
end
