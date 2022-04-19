# WeatherApp

A small app that shows weather based on provided latitude and longitude.
Uses openweathermap.org API to get the data.

Solution uses .Net 6.0 and MVC. To run make sure WeatherApp is a startup project

# Tests
There is a small set of tests checking controller responses and integration with the third party API. To run it
simply use tests tab in VS.

# Notes
Ideally API token should be stored in secure place/config and I shouldn't share mine but to make setup easier I left
it hardcoded