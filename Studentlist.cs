#include <iostream>
#include <string>
#include <unordered_map>
#include <vector>
using namespace std;

// Constants
const int MAX_STUDENTS = 40;
const int MAX_NAME_LENGTH = 50;

// Course Structure
struct Course {
    string code, name;
    Course(string c = "", string n = "") : code(c), name(n) {}
};

// Immutable Grade Class
class Grade {
private:
    int mark;
    char value;
    bool calculated;

    char calculateGrade(int m) const {
        return (m > 69) ? 'A' : (m > 59) ? 'B' : (m > 49) ? 'C' : (m > 39) ? 'D' : 'E';
    }

public:
    Grade() : mark(0), value('E'), calculated(false) {}

    bool setMark(int m) {
        if (calculated || m < 0 || m > 100) return false;
        mark = m;
        value = calculateGrade(m);
        calculated = true;
        return true;
    }

    int getMark() const { return mark; }
    char getGrade() const { return value; }
    bool isCalculated() const { return calculated; }
};

// Student Structure
struct Student {
    string reg_num, name;
    int age;
    Course course;
    Grade grade;

    Student(string r, string n, int a, string cc, string cn) 
        : reg_num(r), name(n), age(a), course(cc, cn) {}

    void display() const {
        cout << "\nReg#: " << reg_num << "\nName: " << name 
             << "\nAge: " << age << "\nCourse: " << course.code 
             << " - " << course.name << "\nMark: " << (grade.isCalculated() ? to_string(grade.getMark()) : "Not set")
             << "\nGrade: " << (grade.isCalculated() ? grade.getGrade() : '-') << "\n";
    }
};

// Student Management System
class StudentManager {
private:
    unordered_map<string, Student> students;
    vector<string> studentOrder;

    bool isValidName(const string& name) const {
        return !name.empty() && name.length() <= MAX_NAME_LENGTH;
    }

public:
    bool addStudent(string reg, string name, int age, string course_code, string course_name) {
        if (students.size() >= MAX_STUDENTS || students.count(reg) || !isValidName(name)) {
            cout << "Invalid input or capacity reached!" << endl;
            return false;
        }

        students.emplace(reg, Student(reg, name, age, course_code, course_name));
        studentOrder.push_back(reg);
        cout << "Student added successfully!" << endl;
        return true;
    }

    bool editStudent(string reg, string name, int age, string course_code, string course_name) {
        auto it = students.find(reg);
        if (it == students.end() || !isValidName(name)) {
            cout << "Student not found or invalid name!" << endl;
            return false;
        }

        it->second.name = name;
        it->second.age = age;
        it->second.course = Course(course_code, course_name);
        cout << "Student updated successfully!" << endl;
        return true;
    }

    bool addMark(string reg, int mark) {
        auto it = students.find(reg);
        if (it == students.end()) {
            cout << "Student not found!" << endl;
            return false;
        }

        if (!it->second.grade.setMark(mark)) {
            cout << "Invalid mark or grade already set!" << endl;
            return false;
        }

        cout << "Mark added successfully!" << endl;
        return true;
    }

    void displayAll() const {
        if (students.empty()) {
            cout << "No students to display!" << endl;
            return;
        }
        
        for (const auto& reg : studentOrder) {
            students.at(reg).display();
        }
    }
};

// Main Menu
int main() {
    StudentManager sm;
    string reg, name, course_code, course_name;
    int age, mark;
    int choice;

    while (true) {
        cout << "\nStudent Management System\n"
             << "1. Add Student\n"
             << "2. Edit Student\n"
             << "3. Add Grade\n"
             << "4. List Students\n"
             << "5. Exit\n"
             << "Choice: ";
        cin >> choice;
        cin.ignore();

        switch (choice) {
            case 1:
                cout << "Enter Registration Number: ";
                getline(cin, reg);
                cout << "Enter Name: ";
                getline(cin, name);
                cout << "Enter Age: ";
                cin >> age;
                cin.ignore();
                cout << "Enter Course Code: ";
                getline(cin, course_code);
                cout << "Enter Course Name: ";
                getline(cin, course_name);
                sm.addStudent(reg, name, age, course_code, course_name);
                break;

            case 2:
                cout << "Enter Registration Number: ";
                getline(cin, reg);
                cout << "Enter New Name: ";
                getline(cin, name);
                cout << "Enter New Age: ";
                cin >> age;
                cin.ignore();
                cout << "Enter New Course Code: ";
                getline(cin, course_code);
                cout << "Enter New Course Name: ";
                getline(cin, course_name);
                sm.editStudent(reg, name, age, course_code, course_name);
                break;

            case 3:
                cout << "Enter Registration Number: ";
                getline(cin, reg);
                cout << "Enter Mark (0-100): ";
                cin >> mark;
                cin.ignore();
                sm.addMark(reg, mark);
                break;

            case 4:
                sm.displayAll();
                break;

            case 5:
                return 0;

            default:
                cout << "Invalid choice!\n";
        }
    }
}
