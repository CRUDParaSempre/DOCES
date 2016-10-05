# DOCES
Trabalho prático de Engenharia de Software

# LEIA ANTES DE CONTRIBUIR!!!!
O BRANCH **MASTER** NAO DEVE SER USADO PARA DESENVOLVIMENTO. TODOS OS PUSH REQUESTS DEVEM SER ENVIADOS PARA O  BRANCH **SPRINT01** - **SPRINT02** OU **SPRINT03**. DEPENDE APENAS DE QUAL PARTE DO PROJETO ESTAMOS.

Abra o terminal ou o app do GitHub
```
git pull origin sprint01
git checkout sprint01
git checkout -b meu_branch
```

Antes de enviar, sincronize novamente com o sprint01 (ou o sprint atual). Uma maneira de fazer isso é dando merge
```
git pull origin sprint01
git checkout meu_branch
git merge sprint01
```

Se quiser clonar apenas o **sprint01**
```
git clone -b sprint01 --single-branch https://github.com/CRUDParaSempre/DOCES.git
```

Evite enviar binários desnecessários que o Unity gera. Envie apenas os arquivos importantes para o desenvolvimento da sua feature.

