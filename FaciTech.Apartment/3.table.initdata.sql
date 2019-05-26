
INSERT INTO Country(Name) Values('India');
INSERT INTO City(Name,CountryId) Values('Bangalore',1);
INSERT INTO Area(Name,CityId) Values('Electronic City',1);
INSERT INTO Area(Name,CityId) Values('Bannerghatta Road',1);
INSERT INTO Area(Name,CityId) Values('Koramangala',1);
INSERT INTO Area(Name,CityId) Values('Jayanagar',1);
INSERT INTO Area(Name,CityId) Values('Whitefield',1);
INSERT INTO Area(Name,CityId) Values('Rajaji Nagar',1);
INSERT INTO Area(Name,CityId) Values('HSR Layout',1);

INSERT INTO SubArea(Name,AreaId) Values('Electronic City Phase 1',1);
INSERT INTO SubArea(Name,AreaId) Values('Electronic City Phase 2',1);
INSERT INTO SubArea(Name,AreaId) Values('Bilekhahalli',3);
INSERT INTO SubArea(Name,AreaId) Values('Kodichikkanahalli',3);
INSERT INTO SubArea(Name,AreaId) Values('Koramangala Block 1',4);
INSERT INTO SubArea(Name,AreaId) Values('Jayanagar Block 7',5);
INSERT INTO SubArea(Name,AreaId) Values('Hopefarm Junction',6);
INSERT INTO SubArea(Name,AreaId) Values('Rajaji Nagar Block 1',7);
INSERT INTO SubArea(Name,AreaId) Values('HSR Layout Sector 5',8);
INSERT INTO SubArea(Name,AreaId) Values('ITPL',6);


INSERT INTO Amenity(Name) Values('Swimming Pool');
INSERT INTO Amenity(Name) Values('Party Hall');
INSERT INTO Amenity(Name) Values('Tennis');
INSERT INTO Amenity(Name) Values('Table Tennis');
INSERT INTO Amenity(Name) Values('BasketBall');
INSERT INTO Amenity(Name) Values('Steam');
INSERT INTO Amenity(Name) Values('Sauna');
INSERT INTO Amenity(Name) Values('Chess');
INSERT INTO Amenity(Name) Values('Multipurpose Hall');
INSERT INTO Amenity(Name) Values('Amphitheatre');
INSERT INTO Amenity(Name) Values('Billiards');
INSERT INTO Amenity(Name) Values('Badminton');



INSERT INTO Community(Name,SubAreaId) Values('SNN Raj Greenbay',1)
INSERT INTO Community(Name,SubAreaId) Values('Alps Southbrook', 2)
INSERT INTO Community(Name,SubAreaId) Values('MJR Clique Hercules', 2)
INSERT INTO Community(Name,SubAreaId) Values('Ranka Ranka Colony', 3)
INSERT INTO Community(Name,SubAreaId) Values('Radiant Lotus', 4)
INSERT INTO Community(Name,SubAreaId) Values('Kuteer Arcade', 5)
INSERT INTO Community(Name,SubAreaId) Values('Jagadhabi Mithila', 6)
INSERT INTO Community(Name,SubAreaId) Values('Godrej Air Nxt', 7)
INSERT INTO Community(Name,SubAreaId) Values('Goyal Orchid Whitefield', 8)
INSERT INTO Community(Name,SubAreaId) Values('Sreejith Sree Arcade', 9)
INSERT INTO Community(Name,SubAreaId) Values('AV6 Trayam', 10)


