# Capture.WindData
Real-time capturing of parameters, System Time, Result Time, Wind Speed and Wind Direction from a Web URL for BRANTFORD AIRPORT, Canada.

## Input:
1. The data is found at the following URL in XML format  http://dd.weather.gc.ca/observations/swob-ml/latest/CTBF-AUTO-minute-swob.xml
2. The data to be retrieved are: 
     a. Wind speed - Refer attribute value "avg_wnd_spd_10m_pst1mt" 
     b. Wind direction - Refer attribute value "avg_wnd_dir_10m_pst1mt" 
     c. Timestamp of sampling - Refer XML node "resultTime"

### Requirements:
1. The data needs to be captured at 30 seconds interval.
2. The data needs to be captured in a CSV file format.
3. New data file to be created when the current data file reaches a size of 5MB. 
