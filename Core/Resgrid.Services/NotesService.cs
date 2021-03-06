﻿using System.Collections.Generic;
using System.Linq;
using Resgrid.Model;
using Resgrid.Model.Events;
using Resgrid.Model.Repositories;
using Resgrid.Model.Services;
using Resgrid.Providers.Bus;

namespace Resgrid.Services
{
	public class NotesService : INotesService
	{
		private readonly IGenericDataRepository<Note> _notesRepository;
		private readonly IEventAggregator _eventAggregator;

		public NotesService(IGenericDataRepository<Note> notesRepository, IEventAggregator eventAggregator)
		{
			_notesRepository = notesRepository;
			_eventAggregator = eventAggregator;
		}

		public List<Note> GetAllNotesForDepartment(int departmentId)
		{
			return _notesRepository.GetAll().Where(x => x.DepartmentId == departmentId).ToList();
		}

		public Note Save(Note note)
		{
			_notesRepository.SaveOrUpdate(note);
			_eventAggregator.SendMessage<NoteAddedEvent>(new NoteAddedEvent(){DepartmentId = note.DepartmentId, Note = note});
			
			return note;
		}

		public List<string> GetDistinctCategoriesByDepartmentId(int departmentId)
		{
			var categories = (from doc in _notesRepository.GetAll()
								where doc.DepartmentId == departmentId
								select doc.Category).Distinct().ToList();

			return categories;
		}

		public Note GetNoteById(int noteId)
		{
			return _notesRepository.GetAll().FirstOrDefault(x => x.NoteId == noteId);
		}

		public void Delete(Note note)
		{
			_notesRepository.DeleteOnSubmit(note);
		}

			public List<Note> GetNotesForDepartmentFiltered(int departmentId, bool isAdmin)
			{
					if (isAdmin)
					{
							return (from note in _notesRepository.GetAll()
											where note.DepartmentId == departmentId
											select note).ToList();
					}

						return (from note in _notesRepository.GetAll()
										where note.DepartmentId == departmentId && note.IsAdminOnly == false
										select note).ToList();
			}
	}
}