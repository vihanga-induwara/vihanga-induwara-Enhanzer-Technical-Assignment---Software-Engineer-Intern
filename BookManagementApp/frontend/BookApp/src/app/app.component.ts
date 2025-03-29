import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // For *ngIf, *ngFor, date pipe
import { FormsModule } from '@angular/forms'; // For ngModel
import { BookService } from './services/book.service';
import { Book } from './models/book';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [CommonModule, FormsModule],
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    books: Book[] = [];
    selectedBook: Book | null = null;
    newBook: Book = { id: 0, title: '', author: '', isbn: '', publicationDate: '' };
    isEditMode = false;
    errorMessage = '';

    constructor(private bookService: BookService) { }

    ngOnInit(): void {
        this.loadBooks();
    }

    loadBooks(): void {
        this.bookService.getBooks().subscribe({
            next: (books) => {
                // No need to parse publicationDate into a Date object
                // The date pipe can handle ISO date strings directly
                this.books = books;
            },
            error: (err) => this.errorMessage = 'Error loading books'
        });
    }

    onAddBook(): void {
        this.bookService.addBook(this.newBook).subscribe({
            next: (book) => {
                // No need to parse publicationDate
                this.books.push(book);
                this.resetForm();
            },
            error: (err) => this.errorMessage = 'Error adding book'
        });
    }

    onEditBook(book: Book): void {
        this.selectedBook = { ...book };
        this.isEditMode = true;
        // Since publicationDate is a string in ISO format (e.g., "1925-04-10T00:00:00"),
        // extract the date part (yyyy-mm-dd) for the form's date input
        this.newBook = { ...book, publicationDate: book.publicationDate.split('T')[0] };
    }

    onUpdateBook(): void {
        if (this.selectedBook) {
            this.bookService.updateBook(this.selectedBook.id, this.newBook).subscribe({
                next: () => {
                    const index = this.books.findIndex(b => b.id === this.selectedBook!.id);
                    // No need to parse publicationDate
                    this.books[index] = { ...this.newBook };
                    this.resetForm();
                },
                error: (err) => this.errorMessage = 'Error updating book'
            });
        }
    }

    onDeleteBook(id: number): void {
        this.bookService.deleteBook(id).subscribe({
            next: () => {
                this.books = this.books.filter(b => b.id !== id);
            },
            error: (err) => this.errorMessage = 'Error deleting book'
        });
    }

    resetForm(): void {
        this.newBook = { id: 0, title: '', author: '', isbn: '', publicationDate: '' };
        this.isEditMode = false;
        this.selectedBook = null;
        this.errorMessage = '';
    }
}