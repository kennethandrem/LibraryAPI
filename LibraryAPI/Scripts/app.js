var ViewModel = function () {
    var self = this;
    self.books = ko.observableArray();
    self.error = ko.observable()
    self.detail = ko.observable();
    self.autores = ko.observableArray();
    self.detailAutor = ko.observableArray();
    self.categorias = ko.observableArray();
    self.detailCat = ko.observableArray();
    self.loading = ko.observable();
    self.loadingC = ko.observable();
    self.loadingA = ko.observable();

    var autorUri = '/api/Autors/';
    var categoriaUri = '/api/Categorias/';
    var booksUri = '/api/Books/';


    self.getBookDetail = function (item) {
        ajaxHelper(booksUri + item.id, 'GET').done(function (data) {
            self.detail(data);
        });
    }
    self.getAutorDetail = function (item) {
        ajaxHelper(autorUri + item.id, 'GET').done(function (data) {
            self.detailAutor(data);
        });
    }
    self.detail = ko.observableArray();

    self.getCategoriaDetail = function (item) {
        ajaxHelper(categoriaUri + item.id, 'GET').done(function (data) {
            self.detailCat(data);
        });
    }
    
    function ajaxHelper(uri, method, data) {
        self.error('');
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllBooks() {
        ajaxHelper(booksUri, 'GET').done(function (data) {
            self.books(data);
            self.loading(false);
        });
    }

    function getAllAutores() {
        ajaxHelper(autorUri, 'GET').done(function (data) {
            self.autores(data);
            self.loadingA(false);
        });
    }

    function getAllCategorias() {
        ajaxHelper(categoriaUri, 'GET').done(function (data) {
            self.categorias(data);
            self.loadingC(false);
        });
    }

    self.newBook = {
        Autor: ko.observable(),
        Categoria: ko.observable(),
        precio: ko.observable(),
        titulo: ko.observable(),
        año: ko.observable()
    }

    self.addBook = function (formElement) {
        var book = {
            autorId: self.newBook.Autor().id,
            categoriaId: self.newBook.Categoria().id,
            precio : self.newBook.precio(),
            titulo : self.newBook.titulo(),
            año: self.newBook.año()
        };

        ajaxHelper(booksUri, 'POST', book).done(function (item) {
            self.books.push(item);
        });
    }

    self.newAutor = {
        nombre: ko.observable(),
        bio: ko.observable(),
        año: ko.observable()
    }

    self.addAutor = function (formElement) {
        var autor = {
            name: self.newAutor.nombre(),
            bio: self.newAutor.bio(),
            año: self.newAutor.año(),
        };

        ajaxHelper(autorUri, 'POST', autor).done(function (item) {
            self.autores.push(item);
        });
    }

    self.newCategoria = {
        nombre: ko.observable(),
        descripcion: ko.observable(),
    }

    self.addCategoria = function (formElement) {
        var cat = {
            name: self.newCategoria.nombre(),
            descripcion: self.newCategoria.descripcion()
        };

        ajaxHelper(categoriaUri, 'POST', cat).done(function (item) {
            self.categorias.push(item);
        });
    }

    getAllBooks();
    self.loading(true);
    getAllAutores();
    self.loadingA(true);
    getAllCategorias();
    self.loadingC(true);

};

ko.applyBindings(new ViewModel());