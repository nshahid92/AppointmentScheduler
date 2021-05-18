# Appointment Scheduler
A simple service to help users schedule appointments

## Recommended Tools
1. Microsoft Visual Studio 2019 (https://visualstudio.microsoft.com/downloads/)
2. .Net Core installed (https://www.microsoft.com/net/download)
3. IIS Express

or

1. Docker installed (https://www.docker.com/community-edition)

## Setup process

### Folder Structure
Unzip the folder named Appointment Scheduler. It consists of AppointmentScheduler.Api and AppointmentScheduler.Services folder as well as the visual studio sln file. The root folder also consists of the docker file.

### Building your application using Visual Studio
1. If you are building and running the application using visual studio then open the sln file in the root folder Appointment Scheduler
2. Once opened, right click on solution file and build and run

#### Run the application
1. You can run the application using IISExpress or Docker from the dropdown on the menu. 
2. Both should open a browser. (Note: You can select your preferred browser from the drop down menu)
3. In the browser you'll see the swagger generated api with two endpoints Get and Post

#### Test the application

1. To test the Post funtion you can hit Try it out and then execute. The json template is ready to be modified. 
Example Request Schema:
{
  "userUuid": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "dateTime": "2021-05-18T14:37:40.660Z"
}

Response:
1) 200 Ok - when appointment created successfully
2) 500 Internal Server Error - appointment cannot be created 

2. To test the Get function you can hit Try it out and then execute. Pass in user uuid into the text box.

Response:
1. 200 Ok
[
  {
    "date": "2021-05-18",
    "startTime": "14:37",
    "endTime": "15:07"
  }
]

2. 404 Not Found
The user uuid does not exist in the system. No appointment was ever created for this user in the system

3. 200 Ok - No appointments for the user


### Building your application using Docker

1. Navigate to the folder containing Docker file. On windows open cmd and type

cd Appointment Scheduler

2. Builder docker file

docker build -t appointmentscheduler .

3. Run docker file

docker run -dp 80:80 appointmentscheduler

#### Test the application

1. Create Appointment

curl -X POST "http://localhost:80/api/Appointments" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"userUuid\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"dateTime\":\"2021-05-18T14:34:58.849Z\"}"


2. GetAppointment
curl -X GET "http://localhost:80/api/Appointments/3fa85f64-5717-4562-b3fc-2c963f66afa6" -H  "accept: text/plain"

