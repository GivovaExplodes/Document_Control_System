namespace LibraryManagementSystem.Data;

public interface Document {
    string DocumentID { get; set; }
    string Title { get; set; }
    string Author { get; set; }
}