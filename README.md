# DOCES
Trabalho prático de Engenharia de Software

# LEIA ANTES DE CONTRIBUIR!!!!
O BRANCH **MASTER** NÃO DEVE SER USADO PARA DESENVOLVIMENTO. TODOS OS PUSH REQUESTS DEVEM SER ENVIADOS PARA O  BRANCH **SPRINT01** - **SPRINT02** OU **SPRINT03**. DEPENDE APENAS DE QUAL PARTE DO PROJETO ESTAMOS.

Se você já tem o projeto no seu computador (você pode clonar o projeto inteiro se quiser). Abra o terminal ou o app do GitHub:
```
git pull origin sprint01
git checkout sprint01
git checkout -b meu_branch
```

Caso não tenha e queira clonar apenas o branch sprint01
```
git clone -b sprint01 --single-branch https://github.com/CRUDParaSempre/DOCES.git
git checkout -b meu_branch
```

Antes de enviar, sincronize novamente com o sprint01 (ou o sprint atual). Uma maneira de fazer isso é dando merge
```
git pull origin sprint01
git checkout meu_branch
git merge sprint01
```

Não envie suas alterações direto para o *sprint01*, prefira subir o teu branch para o GitHub (*git pull origin seu_branch*) e peça um **pull request**. Assim, podemos acompanhar o desenvolvimento de cada feature e reverter rapidamente caso algo dê errado. 

Evite enviar binários desnecessários que o Unity gera. Envie apenas os arquivos importantes para o desenvolvimento da sua feature.

