create table Product
(
pid int primary key identity,
pname varchar(50),
pprovider varchar(50),
pcost money
)

Drop table Product

select pid,pname,c.tname ,pcost from Product p inner join provider c on c.tid = p.pprovider


Select pid, pname, pprovider from Product p inner join provider c on c.tid = p.pprovider where c.tname = p.pprovider

select pid,pname,c.tname from Product p inner join provider c on c.tid = p.pprovider 

select pid,pname  from Product p inner join provider c on c.tid = p.pprovider where c.tid = p.pprovider 
select pid 'id',pname 'name',c.tname  from Product p inner join provider c on c.tid = p.pprovider where c.tname like '123'

select   *from Product 