docker ps -a | awk '//{print $1}' | grep  -v "CONTAINER" | xargs -i sh -c 'docker stop {};docker rm {}'

echo ------------------------------------------------------------
echo ----------------- Prunning docker --------------------------
echo ------------------------------------------------------------
echo

docker system prune -a

echo
echo ------------------------------------------------------------
echo ---------------- Prunning finished -------------------------
echo ------------------------------------------------------------
echo
echo
echo ------------------------------------------------------------
echo ------------------ Docker Network --------------------------
echo ------------------------------------------------------------
echo

echo Name: web-poll-network
echo Subnet: 192.168.0.0/24

docker network create --subnet 192.168.0.0/24 web-poll-network

echo
echo ------------------------------------------------------------
echo ---------------- Building SQL Image ------------------------
echo ------------------------------------------------------------
echo

docker build -t web-poll-db-image -f ./docker/db/DockerfileDB ./docker/db/

echo
echo ------------------------------------------------------------
echo ------------ Building DB Image Finished --------------------
echo ------------------------------------------------------------
echo

echo
echo ------------------------------------------------------------
echo ---------------- Starting DB Container ---------------------
echo ------------------------------------------------------------
echo

echo Name: web-poll-db
echo Subnet: 192.168.0.002
echo Port: 1433
echo User: sa
echo Pwd: saWasHere??01

docker run --net web-poll-network --ip 192.168.0.002 -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=saWasHere??01'  -P -p 1433:1433 --name web-poll-db -d web-poll-db-image

echo
echo ------------------------------------------------------------
echo ------------ Starting DB Container Finished ----------------
echo ------------------------------------------------------------
echo

echo
echo ------------------------------------------------------------
echo ---------------- Building App Image ------------------------
echo ------------------------------------------------------------
echo

docker build -t web-poll-app-image -f ./docker/app/DockerfileApp .

echo
echo ------------------------------------------------------------
echo ------------ Building App Image Finished -------------------
echo ------------------------------------------------------------
echo

echo
echo ------------------------------------------------------------
echo ---------------- Starting DB Container ---------------------
echo ------------------------------------------------------------
echo

echo Name: web-poll-app
echo Subnet: 192.168.0.003
echo Port: 10000

docker run --net web-poll-network --ip 192.168.0.003 -P -p 10000:10000 --name web-poll-app -d web-poll-app-image

echo
echo ------------------------------------------------------------
echo ------------ Starting App Container Finished ---------------
echo ------------------------------------------------------------
echo

