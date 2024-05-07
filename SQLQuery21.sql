create table OrderP 
(
oid int primary key identity,
oname varchar(50),
oprovider varchar(50),
ocount int,
oactive varchar(50),
odate varchar(50),
ocost varchar(50)
)
Drop table OrderP



Select oid, p.pname,c.tname,ocount,SUM(ocount*p.pcost)from OrderP o inner join Product p on p.pid = o.oprovider inner join provider c on c.tid = p.pprovider GROUP BY ocount,p.pcost,oid, p.pname,c.tname



Select oid,oname,oprovider,ocount,odate,oactive from OrderP 

Select oid, oname, oprovider, ocount, odate, oactive,SUM(ocount*p.pcost) from OrderP o inner join Product p on p.pname = o.oprovider GROUP BY ocount,p.pcost,oid, p.pname,oprovider,oname,odate,oactive