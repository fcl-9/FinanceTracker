helm repo add argo-cd https://argoproj.github.io/argo-helm

helm dep update ./argo-cd/

helm install argo-cd ./argo-cd/ --namespace argos-cd --create-namespace --wait

kubectl port-forward svc/argo-cd-argocd-server 8080:443