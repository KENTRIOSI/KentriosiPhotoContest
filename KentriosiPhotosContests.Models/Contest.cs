﻿namespace KentriosiPhotoContest.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    public class Contest
    {
        private ICollection<Prize> prizes;
        private ICollection<User> invitedVoters;
        private ICollection<User> allowedParticipants;
        private ICollection<User> winners;
        private ICollection<Image> contestingImages;

        public Contest()
        {
            this.contestingImages = new HashSet<Image>();
            this.prizes = new HashSet<Prize>();
            this.invitedVoters = new HashSet<User>();
            this.winners = new HashSet<User>();
            this.allowedParticipants = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Contest Title is required.", ErrorMessageResourceName = "Title")]
        [MaxLength(100, ErrorMessageResourceName = "Title", ErrorMessage = "Contest title should be shorter than 100 chars.")]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public ContestStatus Status { get; set; }

        [MaxLength(1000)]
        public string StatusDescription { get; set; }

        public int ContestStrategyId { get; set; }

        public virtual ContestStrategy ContestStrategy { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public int? ContestProfileImageId { get; set; }

        public virtual Image ContestProfileImage { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateModified { get; set; }

        public DateTime? EndDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeadLineDate { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Prize> Prizes
        {
            get { return this.prizes; }
            set { this.prizes = value; }
        }

        [InverseProperty("AppertainingContest")]
        public virtual ICollection<Image> ContestingImages
        {
            get { return this.contestingImages; }
            set { this.contestingImages = value; }
        }

        [InverseProperty("ContestsInvitedIn")]
        public virtual ICollection<User> InvitedVoters
        {
            get { return this.invitedVoters; }
            set { this.invitedVoters = value; }
        }

        [InverseProperty("ContestsParticipated")]
        public virtual ICollection<User> AllowedParticipants
        {
            get { return this.allowedParticipants; }
            set { this.allowedParticipants = value; }
        }

        [InverseProperty("ContestsWon")]
        public virtual ICollection<User> Winners
        {
            get { return this.winners; }
            set { this.winners = value; }
        }
    }
}
