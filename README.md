What is the ApiGateway Project?
=====================
The ApiGateway Project is a open-source project written in .NET Core

The goal of this project is implement the most common used technologies and share with the technical community the best way to develop great applications with .NET

## Give a Star! :star:
If you liked the project or if ApiGateway helped you, please give a star ;)

## How to use:
- You will need the latest Visual Studio 2022 and the latest .NET Core SDK.
- The latest SDK and tools can be downloaded from https://dot.net/core.

Also you can run the appKafka.Debezium Project in Visual Studio Code (Windows, Linux or MacOS).

To know more about how to setup your enviroment visit the [Microsoft .NET Download Guide](https://www.microsoft.com/net/download)

- Install [Docker](https://docs.docker.com/docker-for-windows/install/).

## Technologies implemented:

- ASP.NET Core 8.0 (with .NET Core 8.0)
- .NET Core Native DI
- Ocelot
- k8s
- Azure DevOps pipeline ci/cd 'Azure Container Registry' and 'AKS'

## Ocelot:

- [Ocelot Gateway](https://ocelot.readthedocs.io/en/latest/#)<br/>
As the documentation recommends.<br/>

## Azure DevOps configurations
Setting sensitive variables in Library. According image below.  

<img src="./docs/img/Library Variables.png" alt="Library Variables">  

Setting permissions in Library. According image below.  

<img src="./docs/img/Library Pipeline Permissions.png" alt="Library Variables">  

## Running the project
Go to the 'ApiGateway' project properties and select the 'Multiple startup projects' option and select the 3 projects with the 'Start' action.<br/>

## Running the project with docker
Run the command below to create an external network:  
docker network create api-gateway-network --driver bridge  

Run the following command below in the project root folder at the prompt:  
docker-compose up -d  
or  
docker-compose up --build -d  

## Publish the image to docker.hub
docker-compose build  
docker push docker.io/user/api.gateway:v1  

## Create k8s cluster using k3d
k3d cluster create cluster-k8s-gateway --servers 3 --agents 3 -p "30000:30000@loadbalancer"

## Publish application to k8s
kubectl apply -f .\k8s\deploy.yaml  

## Delete k8s cluster using k3d
k3d cluster delete cluster-k8s-gateway  

## Other commands
k3d cluster list  
kubectl get all  