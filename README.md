### Blue green deployment strategy
Create a Kuberneste deployment as the blue deployment and a service that expose it. Launch green deployment, wait for it to roll out then reconfigure the service to expose it.

### My steps
1. Create a dotnet core webapi application that returns the current date and time in UTC and app version as json. I call it ["NowWebApp"](https://github.com/OliviaHY/NowWebApp);
2. Containerize NowWebApp and test it locally;
3. Create now repository in ECR, authenticate Docker client and push two images that tagged with "version1.0" and "version1.1";
4. Launch EKS cluster and configure kubectl for it;
5. Create deployment and service yaml file for nowwebapp, and deploy 2 deployments("nowebapp-bluedeployment" and "nowebapp-greendeployment") 1 service ("nowwebapp")
6. Create deployments and the service;
7. Create a dotnet core console application that query the datetime api and return the result: [QueryApiConsoleApp](https://github.com/OliviaHY/QueryApiConsoleApp)
8. Run it locally and point it to the Kubernetes service;
9. Verify that the blue-green deployment strategy works;


### Command cheatsheet:
EKS, ECR:

```
eksctl create cluster \
--name prod \
--version 1.14 \
--region us-east-1 \
--nodegroup-name standard-workers \
--node-type t3.medium \
--nodes 3 \
--nodes-min 1 \
--nodes-max 4 \
--ssh-access \
--ssh-public-key my-public-key.pub \
--managed
```
```
ssh-keygen -t rsa
```
```
aws ecr get-login --no-include-email
```
Docker, Kubernetes:
```
docker run -p 8080:80 --rm nowwebapp:version1.0
```
```
kubectl apply -f blue.yaml
```