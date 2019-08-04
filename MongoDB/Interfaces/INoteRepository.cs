using MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Interfaces
{
    public interface INoteRepository
    {
        Task<string> CreateIndex();

        Task<IEnumerable<Note>> GetAllNotes();
        Task<Note> GetNote(string id);

        Task<IEnumerable<Note>> GetNote(string bodyText, DateTime updatedFrom, long headerSizeLimit);

        // add new note;

        Task AddNote(Note item);
        // remove a single note
        Task<bool> RemoveNote(string id);
        // Update just a single note;
        Task<bool> UpdateNote(string id, string body);
        Task<bool> UpdateNote(string id, Note item);

        // full document update;
        Task<bool> UpdateNoteDocument(string id, string body);
        Task<bool> RemoveAllNotes();
    }
}
