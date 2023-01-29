﻿// <auto-generated />
using System;
using MVCD2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCD2.Migrations
{
    [DbContext(typeof(companyContext))]
    partial class companyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCD2.Models.Department", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("employeeSSN")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("MVCD2.Models.dependents", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int>("ESSN")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeSSN")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relationship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("EmployeeSSN");

                    b.ToTable("dependents");
                });

            modelBuilder.Entity("MVCD2.Models.employee", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSN"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int?>("Department2Number")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SuperVisorSSN")
                        .HasColumnType("int");

                    b.Property<int?>("deptid")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.HasIndex("Department2Number");

                    b.HasIndex("SuperVisorSSN");

                    b.HasIndex("deptid")
                        .IsUnique()
                        .HasFilter("[deptid] IS NOT NULL");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("MVCD2.Models.location", b =>
                {
                    b.Property<int>("DeptNumber")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DeptNumber", "Location");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("MVCD2.Models.project", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<int>("DeptNum")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.HasIndex("DeptNum");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("MVCD2.Models.workOn", b =>
                {
                    b.Property<int>("ESSN")
                        .HasColumnType("int");

                    b.Property<int>("projectNum")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectNumber")
                        .HasColumnType("int");

                    b.HasKey("ESSN", "projectNum");

                    b.HasIndex("ProjectNumber");

                    b.ToTable("workOns");
                });

            modelBuilder.Entity("MVCD2.Models.dependents", b =>
                {
                    b.HasOne("MVCD2.Models.employee", "Employee")
                        .WithMany("Dependents")
                        .HasForeignKey("EmployeeSSN");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MVCD2.Models.employee", b =>
                {
                    b.HasOne("MVCD2.Models.Department", "Department2")
                        .WithMany("employees")
                        .HasForeignKey("Department2Number");

                    b.HasOne("MVCD2.Models.employee", "SuperVisor")
                        .WithMany("Employees")
                        .HasForeignKey("SuperVisorSSN");

                    b.HasOne("MVCD2.Models.Department", "Department")
                        .WithOne("employee")
                        .HasForeignKey("MVCD2.Models.employee", "deptid");

                    b.Navigation("Department");

                    b.Navigation("Department2");

                    b.Navigation("SuperVisor");
                });

            modelBuilder.Entity("MVCD2.Models.location", b =>
                {
                    b.HasOne("MVCD2.Models.Department", "Department")
                        .WithMany("DepartmentLocations")
                        .HasForeignKey("DeptNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVCD2.Models.project", b =>
                {
                    b.HasOne("MVCD2.Models.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DeptNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVCD2.Models.workOn", b =>
                {
                    b.HasOne("MVCD2.Models.employee", "employee")
                        .WithMany("WorksOnProjects")
                        .HasForeignKey("ESSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCD2.Models.project", "Project")
                        .WithMany("WorksOnProjects")
                        .HasForeignKey("ProjectNumber");

                    b.Navigation("Project");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("MVCD2.Models.Department", b =>
                {
                    b.Navigation("DepartmentLocations");

                    b.Navigation("Projects");

                    b.Navigation("employee");

                    b.Navigation("employees");
                });

            modelBuilder.Entity("MVCD2.Models.employee", b =>
                {
                    b.Navigation("Dependents");

                    b.Navigation("Employees");

                    b.Navigation("WorksOnProjects");
                });

            modelBuilder.Entity("MVCD2.Models.project", b =>
                {
                    b.Navigation("WorksOnProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
