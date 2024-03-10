using AutoMapper;
using DemoPostgresAPI.Data;
using DemoPostgresAPI.DTO;
using DemoPostgresAPI.Models;
using Microsoft.EntityFrameworkCore;
using NanoidDotNet;
using System;
using System.Reflection.Emit;

namespace DemoPostgresAPI.Services
{
    public interface IStudentService
    {
        Student CreateStudent(string name);
        Student GetStudent(string id);
        IEnumerable<StudentDto> SearchStudentsByName(string name);
    }

    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        private readonly Random _random;
        private readonly string _characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private readonly IMapper _mapper;

        public StudentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _random = new Random();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Student CreateStudent(string name)
        {
            var randomId = GenerateRandomId();
            var student = new Student
            {
                ROWID = randomId,
                Name = name,
                CreatedAt = DateTime.UtcNow
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return student;
        }

        public Student GetStudent(string id)
        {
            return _context.Students.FirstOrDefault(s => s.ROWID == id);
        }

        public IEnumerable<StudentDto> SearchStudentsByName(string name)
        {
            var students = _context.Students.Where(s => EF.Functions.Like(s.Name, $"%{name}%")).ToList();
            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return studentDtos;
        }

        private string GenerateRandomId()
        {
            var now = DateTime.UtcNow;
            var dateString = now.ToString("yyMMdd");

            var randomCharacters = "";
            var randomLowercase = "";
            var randomUppercase = "";

            for (int i = 0; i < 2; i++)
            {
                randomCharacters += _characters[_random.Next(_characters.Length)];
                randomLowercase += _characters.Substring(26 + _random.Next(26), 1);
                randomUppercase += _characters.Substring(_random.Next(26), 1);
            }

            var mixedCharacters = randomCharacters + randomLowercase + randomUppercase;

            var shuffledCharacters = new string(mixedCharacters.OrderBy(c => _random.Next()).ToArray());

            return dateString + shuffledCharacters;
        }
    }
}