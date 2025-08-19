docker build -t tasks-daily:v1.0 .

docker tag tasks-daily:v1.0 skemper111/tasks-daily:latest

docker push skemper111/tasks-daily:latest

