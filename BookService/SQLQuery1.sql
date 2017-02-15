SELECT * FROM Books LEFT OUTER JOIN Authors ON Books.AuthorId = Authors.Id
SELECT * FROM Books INNER JOIN Authors ON Books.AuthorId = Authors.Id ORDER BY Books.Id ASC

SELECT * FROM Books,Authors WHERE Books.AuthorId = Authors.Id
SELECT * FROM Books INNER JOIN Authors ON Books.AuthorId = Authors.Id WHERE Authors.Id = 41
SELECT * FROM Books INNER JOIN Authors ON Books.AuthorId = Authors.Id WHERE Books.Id = 9
SELECT * FROM Books WHERE Books.Id = 9