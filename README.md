# Crud Utilizando .Net Core, Oracle 11g, Angular 11 e Bootstrap 3.3.7

## Tela do CRUD

![alt text](https://raw.githubusercontent.com/consule/FrontAndBackend/main/portal/src/assets/telaSistema.png)

## Criação da tabela

`CREATE TABLE CC_CONTEUDO (
       CODIGO_UNICO NUMBER(10), 
       TITULO VARCHAR2(200), 
       SUBTITULO VARCHAR2(200),
       DATAPUBLICACAO DATE
);`

## Adicionando a chave primária

`ALTER TABLE CC_CONTEUDO ADD (
CONSTRAINT CC_CONTEUDO_PK PRIMARY KEY(CODIGO_UNICO));`

## Adicionando a sequencia da tabela

`CREATE SEQUENCE SEQ_CC_CONTEUDO START WITH 1;`

## Criando a trigger que faz o auto incremento da tabela

`CREATE OR REPLACE TRIGGER T_CC_CONTEUDO
BEFORE INSERT ON CC_CONTEUDO
FOR EACH ROW
BEGIN
    SELECT SEQ_CC_CONTEUDO.NEXTVAL 
    INTO :NEW.CODIGO_UNICO 
    FROM DUAL;
END;`

