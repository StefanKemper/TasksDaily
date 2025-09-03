docker rmi skemper111/tasks-daily:api-latest && docker rmi tasks-daily:api-latest

docker build -t tasks-daily:api-latest .

docker tag tasks-daily:api-latest skemper111/tasks-daily:api-latest

docker push skemper111/tasks-daily:api-latest

