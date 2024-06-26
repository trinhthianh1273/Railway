﻿// <auto-generated />
using System;
using BE.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BE.Persistence.Migrations
{
    [DbContext(typeof(BEContext))]
    partial class BEContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BE.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BookingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("CancellationFee")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("CancellationReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CancellationTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("PaidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PaidTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int")
                        .HasColumnName("PassengerId");

                    b.Property<int?>("PaymentMethodId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("PaymentMethodID");

                    b.Property<DateTime>("PaymentTerm")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("RefundAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("RefundTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalFare")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("TotalPayment")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.BookingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BookingStatusID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int")
                        .HasColumnName("BookingID");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .IsFixedLength();

                    b.Property<DateTime>("StatusTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("statusTime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("BookingStatus", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.BookingTicket", b =>
                {
                    b.Property<int>("BookingId")
                        .HasColumnType("int")
                        .HasColumnName("BookingID");

                    b.Property<int>("TicketId")
                        .HasColumnType("int")
                        .HasColumnName("TicketID");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookingId", "TicketId");

                    b.HasIndex("TicketId");

                    b.ToTable("BookingTicket", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CoachID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoachNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TrainId");

                    b.HasIndex(new[] { "CoachNo" }, "IX_Coach")
                        .IsUnique();

                    b.ToTable("Coach", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.Function", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FunctionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FunctionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "FunctionName" }, "IX_Function_1")
                        .IsUnique();

                    b.ToTable("Function", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GroupID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "GroupName" }, "IX_Group_1")
                        .IsUnique();

                    b.ToTable("Group", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.GroupFunction", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("GroupID");

                    b.Property<int>("FunctionId")
                        .HasColumnType("int")
                        .HasColumnName("FunctionID");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GroupId", "FunctionId");

                    b.HasIndex("FunctionId");

                    b.ToTable("GroupFunction", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.GroupUser", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("GroupID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupUser", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PassengerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Genger")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Image")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNo")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("token");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email", "PhoneNo" }, "IX_Passenger_1")
                        .IsUnique()
                        .HasFilter("[PhoneNo] IS NOT NULL");

                    b.ToTable("Passenger", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PaymentMethodID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethodName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PaymentMethodName" }, "IX_PaymentMethod_1")
                        .IsUnique();

                    b.ToTable("PaymentMethod", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RouteID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartureStation")
                        .HasColumnType("int")
                        .HasColumnName("DepartureStation");

                    b.Property<int>("DestinationStation")
                        .HasColumnType("int")
                        .HasColumnName("DestinationStation");

                    b.Property<decimal>("RouteFare")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("RouteName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartureStation");

                    b.HasIndex("DestinationStation");

                    b.HasIndex(new[] { "RouteName" }, "IX_Route_1")
                        .IsUnique();

                    b.ToTable("Route", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SeatID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoachId")
                        .HasColumnType("int")
                        .HasColumnName("CoachID");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SeatNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SeatTypeId")
                        .HasColumnType("int")
                        .HasColumnName("SeatTypeID");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("SeatTypeId");

                    b.HasIndex(new[] { "SeatNo" }, "IX_Seat_1")
                        .IsUnique();

                    b.ToTable("Seat", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.SeatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SeatTypeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("RaitoFare")
                        .HasColumnType("float");

                    b.Property<string>("SeatTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "SeatTypeName" }, "IX_SeatType_1")
                        .IsUnique();

                    b.ToTable("SeatType", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StationID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "StationName" }, "IX_Station_1")
                        .IsUnique();

                    b.ToTable("Station", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TicketID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Fare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SeatId")
                        .HasColumnType("int")
                        .HasColumnName("SeatID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TripId")
                        .HasColumnType("int")
                        .HasColumnName("TripID");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SeatId");

                    b.HasIndex("TripId");

                    b.ToTable("Ticket", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TrainID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrainName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "TrainName" }, "IX_Train_1")
                        .IsUnique();

                    b.ToTable("Train", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TripID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArriveTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime");

                    b.Property<int>("RouteId")
                        .HasColumnType("int")
                        .HasColumnName("RouteID");

                    b.Property<int>("TrainId")
                        .HasColumnType("int")
                        .HasColumnName("TrainID");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.HasIndex("TrainId");

                    b.ToTable("Trip", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("token");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email", "UserName" }, "IX_User_1")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("BE.Domain.Entities.Booking", b =>
                {
                    b.HasOne("BE.Domain.Entities.Passenger", "Passenger")
                        .WithMany("Bookings")
                        .HasForeignKey("PassengerId")
                        .IsRequired()
                        .HasConstraintName("FK_Booking_Passenger");

                    b.HasOne("BE.Domain.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany("Bookings")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Booking_PaymentMethod");

                    b.Navigation("Passenger");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("BE.Domain.Entities.BookingStatus", b =>
                {
                    b.HasOne("BE.Domain.Entities.Booking", "Booking")
                        .WithMany("BookingStatuses")
                        .HasForeignKey("BookingId")
                        .IsRequired()
                        .HasConstraintName("FK_BookingStatus_Booking");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("BE.Domain.Entities.BookingTicket", b =>
                {
                    b.HasOne("BE.Domain.Entities.Booking", "Booking")
                        .WithMany("BookingTickets")
                        .HasForeignKey("BookingId")
                        .IsRequired()
                        .HasConstraintName("FK_BookingTicket_Booking");

                    b.HasOne("BE.Domain.Entities.Ticket", "Ticket")
                        .WithMany("BookingTickets")
                        .HasForeignKey("TicketId")
                        .IsRequired()
                        .HasConstraintName("FK_BookingTicket_Ticket");

                    b.Navigation("Booking");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("BE.Domain.Entities.Coach", b =>
                {
                    b.HasOne("BE.Domain.Entities.Train", "Train")
                        .WithMany("Coaches")
                        .HasForeignKey("TrainId")
                        .IsRequired()
                        .HasConstraintName("FK_Coach_Train");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("BE.Domain.Entities.GroupFunction", b =>
                {
                    b.HasOne("BE.Domain.Entities.Function", "Function")
                        .WithMany("GroupFunctions")
                        .HasForeignKey("FunctionId")
                        .IsRequired()
                        .HasConstraintName("FK_GroupFunction_Function");

                    b.HasOne("BE.Domain.Entities.Group", "Group")
                        .WithMany("GroupFunctions")
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("FK_GroupFunction_Group");

                    b.Navigation("Function");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("BE.Domain.Entities.GroupUser", b =>
                {
                    b.HasOne("BE.Domain.Entities.Group", "Group")
                        .WithMany("GroupUsers")
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("FK_GroupUser_Group");

                    b.HasOne("BE.Domain.Entities.User", "User")
                        .WithMany("GroupUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_GroupUser_User");

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BE.Domain.Entities.Route", b =>
                {
                    b.HasOne("BE.Domain.Entities.Station", "DepartureStationNavigation")
                        .WithMany("RouteDepartureStationNavigations")
                        .HasForeignKey("DepartureStation")
                        .IsRequired()
                        .HasConstraintName("FK_Route_Station");

                    b.HasOne("BE.Domain.Entities.Station", "DestinationStationNavigation")
                        .WithMany("RouteDestinationStationNavigations")
                        .HasForeignKey("DestinationStation")
                        .IsRequired()
                        .HasConstraintName("FK_Route_Destination_Station");

                    b.Navigation("DepartureStationNavigation");

                    b.Navigation("DestinationStationNavigation");
                });

            modelBuilder.Entity("BE.Domain.Entities.Seat", b =>
                {
                    b.HasOne("BE.Domain.Entities.Coach", "Coach")
                        .WithMany("Seats")
                        .HasForeignKey("CoachId")
                        .IsRequired()
                        .HasConstraintName("FK_Seat_Coach");

                    b.HasOne("BE.Domain.Entities.SeatType", "SeatType")
                        .WithMany("Seats")
                        .HasForeignKey("SeatTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_Seat_SeatType");

                    b.Navigation("Coach");

                    b.Navigation("SeatType");
                });

            modelBuilder.Entity("BE.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("BE.Domain.Entities.Seat", "Seat")
                        .WithMany("Tickets")
                        .HasForeignKey("SeatId")
                        .IsRequired()
                        .HasConstraintName("FK_Ticket_Seat");

                    b.HasOne("BE.Domain.Entities.Trip", "Trip")
                        .WithMany("Tickets")
                        .HasForeignKey("TripId")
                        .IsRequired()
                        .HasConstraintName("FK_Ticket_Trip");

                    b.Navigation("Seat");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("BE.Domain.Entities.Trip", b =>
                {
                    b.HasOne("BE.Domain.Entities.Route", "Route")
                        .WithMany("Trips")
                        .HasForeignKey("RouteId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip_Route");

                    b.HasOne("BE.Domain.Entities.Train", "Train")
                        .WithMany("Trips")
                        .HasForeignKey("TrainId")
                        .IsRequired()
                        .HasConstraintName("FK_Trip_Train");

                    b.Navigation("Route");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("BE.Domain.Entities.Booking", b =>
                {
                    b.Navigation("BookingStatuses");

                    b.Navigation("BookingTickets");
                });

            modelBuilder.Entity("BE.Domain.Entities.Coach", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("BE.Domain.Entities.Function", b =>
                {
                    b.Navigation("GroupFunctions");
                });

            modelBuilder.Entity("BE.Domain.Entities.Group", b =>
                {
                    b.Navigation("GroupFunctions");

                    b.Navigation("GroupUsers");
                });

            modelBuilder.Entity("BE.Domain.Entities.Passenger", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BE.Domain.Entities.PaymentMethod", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BE.Domain.Entities.Route", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("BE.Domain.Entities.Seat", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("BE.Domain.Entities.SeatType", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("BE.Domain.Entities.Station", b =>
                {
                    b.Navigation("RouteDepartureStationNavigations");

                    b.Navigation("RouteDestinationStationNavigations");
                });

            modelBuilder.Entity("BE.Domain.Entities.Ticket", b =>
                {
                    b.Navigation("BookingTickets");
                });

            modelBuilder.Entity("BE.Domain.Entities.Train", b =>
                {
                    b.Navigation("Coaches");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("BE.Domain.Entities.Trip", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("BE.Domain.Entities.User", b =>
                {
                    b.Navigation("GroupUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
