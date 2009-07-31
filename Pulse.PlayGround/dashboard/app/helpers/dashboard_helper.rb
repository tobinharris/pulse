module DashboardHelper

  class Chart
    attr_accessor :name
    attr_accessor :data
    attr_accessor :max
    attr_accessor :height
    attr_accessor :width

    def initialize(name, data)
      self.name = name
      self.data = data
      self.max = data.collect{|i| i[1]}.max
      self.height = 100
      self.width = 300
    end

    def chart_data(args)
      data, max = args
      return nil if max == 0 || data.size == 0
      #max value to show on chart should be a bit more than the max value passed in
      max += max * 0.2
      encode = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789'

      encoded = data.map do |result|
        char =  62 * result[1] / max.to_f
        encode[char.round,1]
      end.join

      max_in_seconds = (max/1)
      half_in_seconds = (max/2)
      "#{encoded}&chxl=0:|0s|#{half_in_seconds}|#{max_in_seconds}"
    end

    def google_url
      "http://chart.apis.google.com/chart?cht=ls&chs=#{self.width}x#{self.height}&chm=B,e6f2fa,0,0,0|R,000000,0,0.998,1.0&chco=0f7fcf&chxt=r&chd=s:#{self.chart_data([self.data.reverse,self.max])}"
    end 

    def to_s
      google_url
    end
  end
  
end
